import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';
import SVGInline from 'react-svg-inline';

import { menuItems } from 'shared/utils/menuItems';
import { FooterLinks } from './FooterLinks';
import UpButton from './UpButton';
import { logos, bottomLinks } from '../data';
import './Footer.scss';

const Footer = ({ locale }) => {
  const b = block('footer');
  const logoItems = logos.map(item => (
    <li className={b('logo-item')} key={item}>
      <img className={b('logo-item-img')} src={item} alt="logo" />
    </li>
  ));
  return (
    <footer className={b()}>
      <div className={b('wrapper')}>
        <div className={b('top')}>
          <FooterLinks
            flatPagesList={[]}
            links={menuItems}
            locale={locale}
          />
          <UpButton text={locale.upbutton} />
        </div>
        <div className={b('text')}>
          <p className={b('text-paragraph')}>{locale.footerText3}</p>
        </div>
      </div>
    </footer>
  );
};

Footer.propTypes = {
  locale: PropTypes.object,
};

export default React.memo(Footer);