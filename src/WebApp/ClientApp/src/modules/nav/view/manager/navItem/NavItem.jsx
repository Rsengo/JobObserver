import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import block from 'bem-cn'

import './NavItem.styl'

class NavItem extends Component {
    render() {
        const b = block('nav-item')
        const {name, rout, key} = this.props.item;
        const { active, onItemClick, index } = this.props;
        return (
            <Link to={rout}>
                <div key={key} className={b({active : active})} onClick={() => onItemClick(index)}>
                    {name}
                </div>
            </Link>
        )
    }
}

export default NavItem