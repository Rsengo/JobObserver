import dayjs from 'dayjs';

class FullEventLineConverter {
  convertFullEvent = event => ({
    ID: +event.ID,
    tourneyID: +event.tourneyID,
    sportID: +event.sportID,
    sportName: event.sportName,
    tourneyName: event.tourneyName,
    teams: this.convertorTeams(event.teams),
    date: this.cotvertorEventDate(event.eventDate),
    coefGroups: this.convertCoefGroups(event.coefGroups),
    countryID: event.countryID,
  })

  convertorTeams = teams => `${teams[0]} - ${teams[1]}`

  cotvertorEventDate = date => dayjs(date).format('DD-MM-YYYY HH:mm')

  convertCoefGroups = coefs => {
    const groupsCoefs = this.combineCoefsToGroups(coefs);
    const groupCoefsWithGroups = groupsCoefs.map(temp => ({ ...temp, coefs: this.groupCoefsInsideGroup(temp.coefs) }));
    return groupCoefsWithGroups;
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

  convertorStaticticList = statisticList => {
    const mapingStatisticList = Object.values(statisticList).map(statisticItem => ({
      text: statisticItem.EXTENDET_NAME.replace(/\[|\]/g, ''),
      value: statisticItem.ID,
    }));
    return mapingStatisticList;
  }
}

export default FullEventLineConverter;