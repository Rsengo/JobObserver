import React from 'react';
import block from 'bem-cn';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';

import './FooterLinks.scss';

export const FooterLinks = ({ links, locale }) => {
  const b = block('footer-links');
  const linksItems = links.map(item => (
    <li className={b('links-list-item')} key={item.textIdent}>
      <Link className={b('link')} to={item.link}>{locale[item.textIdent]}</Link>
    </li>
  ));

  return (
    <nav className={b()}>
      <ul className={b('list')}>{[...linksItems]}</ul>
    </nav>
  );
};

FooterLinks.propTypes = {
  links: PropTypes.array.isRequired,
  locale: PropTypes.object.isRequired,
};