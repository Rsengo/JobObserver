import React from 'react';
import { Component } from 'react'
import PropTypes from 'prop-types'
import { withRouter } from 'react-router-dom'
import { block } from 'bem-cn'
import { Button, Avatar, Typography } from '@material-ui/core'

import './Header.styl'

const Header = () => {
    var b = block('header');
    return (
        <div className={b()}>
            <Avatar className='header__avatar'>JO</Avatar>
            <Typography variant="h4">
                Job Observer
            </Typography>
        </div>
    )
}

export default Header