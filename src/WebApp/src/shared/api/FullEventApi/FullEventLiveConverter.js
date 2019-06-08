import dayjs from 'dayjs';
import { statusTypes } from './FullEventUtils';

class FullEventLineConverter {
  convertFullEvent = (event, previewEventCoefs) => ({
    ID: +event.ID,
    tourneyID: +event.tourneyID,
    sportID: +event.sportID,
    sportName: event.sportName,
    tourneyName: event.tourneyName,
    countryID: event.countryID,
    teams: this.convertorTeams(event.teams),
    date: this.cotvertorEventDate(event.eventDate),
    coefGroups: this.convertCoefGroups(event.coefGroups, previewEventCoefs),
    score: event.scores.replace(' - ', ':'),
    timesScore: this.convertorScoreTimes(event.pscores),
    time: event.sportID !== 4 ? this.convertorTime(event.time) : '',
  })

  convertorTime = time => `${Math.floor(time / 60)}'`

  convertorScoreTimes = timesList => `(${Object.values(timesList)
    .map(time => `${time.SCORE_ONE}:${time.SCORE_TWO}`).join(';')})`

  convertorTeams = teams => `${teams[0]} - ${teams[1]}`

  cotvertorEventDate = date => dayjs(date).format('DD-MM-YYYY HH:mm')

  convertCoefGroups = (coefs, previewEventCoefs) => {
    const groupsCoefs = this.combineCoefsToGroups(coefs);
    const groupCoefsWithGroups = groupsCoefs.map(temp => ({ ...temp, coefs: this.groupCoefsInsideGroup(temp.coefs) }));
    return previewEventCoefs ? this.addUpdateStatuses(groupCoefsWithGroups, previewEventCoefs) : groupCoefsWithGroups;
  }

  addUpdateStatuses = (groupCoefsWithGroups, previewEventCoefs) => groupCoefsWithGroups.map(temp => ({
    ...temp,
    coefs: temp.coefs.map(tempGroup => tempGroup.map(
      tempCoef => {
        const findedGroup = previewEventCoefs.find(tempPrevious => tempPrevious.ID === tempCoef.ocGroupID);
        const findedCoefs = findedGroup === undefined ?
          undefined : [].concat(...findedGroup.coefs);
        const findedCoef = findedCoefs === undefined ?
          undefined : findedCoefs.find(tempFind => tempFind.betNameLong === tempCoef.betNameLong);
        return {
          ...this.convertCoefInfo(tempCoef),
          updateStatus: this.defineStatus(findedCoef, tempCoef),
        };
      },
    )),
  }))

  convertCoefInfo = coef => ({
    ...coef,
    ID: +coef.ID,
    betslipInfoFull: {
      big_bet_pointer: coef.betslipInfoFull.big_bet_pointer,
      isLive: coef.betslipInfoFull.isLive,
      rate: coef.betslipInfoFull.rate,
      eventID: +coef.betslipInfoFull.eventId,
    },
    betrouteID: undefined,
  })

  defineStatus = (oldCoef, newCoef) => {
    if (oldCoef === undefined || newCoef.rate === oldCoef.rate) return statusTypes.DEFAULT;
    return newCoef.rate > oldCoef.rate ? statusTypes.INCREASE : statusTypes.REDUCED;
  }

  combineCoefsToGroups = coefs => {
    const uniqueGroups = coefs.map(coef => ({ ID: +coef.ocGroupID, name: coef.ocGroupName, isOpen: true }))
      .filter((v, i, a) => a.findIndex(t => t.ID === v.ID) === i);

    const coefGroups = uniqueGroups.map(temp => ({ ...temp,
      coefs: coefs.reduce((newArray, tempCoef) => {
        return tempCoef.ocGroupID === temp.ID ? [...newArray, tempCoef] : newArray;
      }, []) }));

    return coefGroups;
  }

  groupCoefsInsideGroup = coefs => {
    if (coefs.length <= 3) return [coefs.map(temp => this.convertCoefInfo(temp))];
    const convertedCoefs = [];
    for (let i = 0; i < coefs.length; i += 2) {
      const newGroup = [this.convertCoefInfo(coefs[i])];
      if (coefs[i + 1]) newGroup.push(this.convertCoefInfo(coefs[i + 1]));
      convertedCoefs.push(newGroup);
    }
    return convertedCoefs;
  }
}

export default FullEventLineConverter;