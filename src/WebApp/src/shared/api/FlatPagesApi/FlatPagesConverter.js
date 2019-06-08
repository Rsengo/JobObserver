import { sortFlatPages } from './FlatPagesUtils';

export class FlatPagesConverter {
  convertFlatPages = data => {
    const convertedData = data.map(flatpage => {
      return {
        name: flatpage.name,
        priority: flatpage.priority,
        idName: flatpage.id_name,
        id: flatpage.id,
        text: flatpage.text,
      };
    });
    return sortFlatPages(convertedData);
  }
}