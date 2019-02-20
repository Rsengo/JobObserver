import React from 'react'
import { Component } from 'react'
import { bind } from 'decko'

import { workerRouters } from '../../../data/dictionary'
import NavItem from '../navItem/NavItem'

import './Nav.styl'

class Nav extends Component {

    constructor(props) {
        super(props);

        this.state = {
            activeLink: 0,
        }
    }

    @bind
    changeActivLink(id) {
        this.setState({
            activeLink: id,
        })
    }

    render() {
        const navList = workerRouters.map((navItem, index) => 
            <NavItem
                item={navItem}
                key={index}
                onItemClick={this.changeActivLink}
                active={index === this.state.activeLink ? true : false}
                index={index}
            />
        )
        return (
            <div className='nav-container'>
                <div className='nav'>
                    {navList}
                </div> 
            </div>  
        )
    }
}

export default Nav