import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';
import { Link, withRouter } from 'react-router-dom';

import { appMenuItems } from 'shared/utils/menuItems';
import './MainMenu.scss';

const MainMenu = ({ locale, location }) => {
  const b = block('main-menu');
  const items = appMenuItems.map(item => {
    const isActive = location.pathname === item.link;
    return (
      <li className={b('list-item', { active: isActive })} key={item.textIdent}>
        <Link
          to={item.link}
          className={b('list-item-link').toString()}
        >
          {locale[item.textIdent]}
        </Link>
      </li>
    );
  });
  return (
    <nav className={b()}>
      <ul className={b('list')}>
        {items}
      </ul>
    </nav>
  );
};

MainMenu.propTypes = {
  locale: PropTypes.object,
  location: PropTypes.object.isRequired,
};

export default withRouter(React.memo(MainMenu));