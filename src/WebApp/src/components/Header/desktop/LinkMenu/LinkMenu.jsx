import React from 'react';
import block from 'bem-cn';
import SVGInline from 'react-svg-inline';
import { Link } from 'react-router-dom';

import { topLinks } from '../../data';
import './LinkMenu.scss';

const LinkMenu = () => {
  const b = block('link-menu');
  const items = topLinks.map(item => {
    return <li className={b('item')} key={item.id}>
      {
        item.type === 'href' ?
          <a className={b('link')} href={item.link}>
            <SVGInline className={b('link-icon', { type: item.id }).toString()} svg={item.icon} />
          </a> :
          <Link className={b('link')} to={item.link}>
            <SVGInline className={b('link-icon', { type: item.id }).toString()} svg={item.icon} />
          </Link>
      }
    </li>;
  });
  return <ul className={b()}>{items}</ul>;
};

export default React.memo(LinkMenu);