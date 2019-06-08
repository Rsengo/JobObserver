export class SportMenuConverter {
  convertSports(data) {
    const sortedData = data.sort((a, b) => a.ID - b.ID);
    return sortedData;
  }
}