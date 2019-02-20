import React from 'react'
import { Component } from 'react'
import { block } from 'bem-cn'
import PropTypes from 'prop-types'

import './Button.styl'

class Button extends Component {

    static propTypes = {

        onClick: PropTypes.func.isRequired,

        value: PropTypes.string.isRequired,
        color: PropTypes.string,
        size: PropTypes.string,

    }

    render() {
        const b = block('button')
        const { value , color, onClick, size, isDisabled } = this.props
        return (
            <button
                className={b({color: color}, {size: size})}
                onClick={onClick}
                disabled={isDisabled}
            >
                {value}
            </button>
        )
    }
}

export default Button