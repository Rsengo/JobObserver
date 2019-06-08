import EnPNG from './img/en.png';
import RuPNG from './img/ru.png';
import KzPNG from './img/kz.png';

export const languages = {
  RU: 'ru-ru',
  EN: 'en-US',
  KZ: 'kk-KZ',
};

export const languagesWithIcons = {
  'ru-ru': { lang: languages.RU, icon: RuPNG, text: 'Русский' },
  'en-US': { lang: languages.EN, icon: EnPNG, text: 'English' },
  'kk-KZ': { lang: languages.KZ, icon: KzPNG, text: 'Казакша' },
};

export const shortLanguages = {
  'ru-ru': 'ru',
  'en-US': 'en',
  'kk-KZ': 'kk',
};