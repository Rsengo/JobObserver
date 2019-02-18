import React from 'react'
import { Component } from 'react'
import { AuthWrapper } from '../../../features/auth'
import { block } from 'bem-cn'

import LogoImg from '../img/logo.png'
import './Header.styl'

class Header extends Component {
    render() {
        const b = block('header')
        return(
            <div className={b()}>
                <img 
                    className={b('logo')} 
                    src={LogoImg} 
                    alt='Sorry, image not provide'
                />
                <AuthWrapper 
                />
            </div>
        )
    }
}

export default Header