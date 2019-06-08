import dayjs from 'dayjs';
import mainBets from '../../utils/mainBets';

class LineConverter {
  convertorLineTourneys = tourneys => tourneys.map(temp => ({
    ...temp, events: [], isOpen: false,
  }))

  convertorLineEvents = events => events.map(
    tempEvent => ({
      ID: +tempEvent.ID,
      additionalBetsCount: +tempEvent.additionalBetsCount,
      eventDate: dayjs(tempEvent.eventDate).format('DD-MM-YYYY HH:mm'),
      sportID: +tempEvent.sportID,
      sportName: tempEvent.sportName,
      tourneyID: +tempEvent.tourneyID,
      tourneyName: tempEvent.tourneyName,
      teams: this.convertorTeams(tempEvent.teams),
      coefs: this.convertorCoefs(tempEvent.coefs),
    }),
  )

  convertorTeams = teams => `${teams[0]} - ${teams[1]}`

  convertorCoefs = coefs => this.filterCoefs(coefs.map(temp => ({
    ID: +temp.ID,
    betNameLong: temp.betNameLong,
    betNameShort: temp.betNameShort,
    groupID: +temp.ocGroupID,
    ocGroupName: temp.ocGroupName,
    rate: +temp.rate,
    eventId: +temp.betslipInfoFull.eventId,
    bigBetPointer: temp.betslipInfoFull.big_bet_pointer,
    isLive: temp.betslipInfoFull.isLive,
  })))

  filterCoefs = coefs => mainBets.map(temp => coefs.find(tempFinded => tempFinded.ID === temp) || null)

  convertorTopEvents = events => events;
}

export default LineConverter;