import React from 'react'
import { Component } from 'react'
import { block } from 'bem-cn'
import PropTypes from 'prop-types'

import './Input.styl'

class Input extends Component {

    static propTypes = {

        onClick: PropTypes.func.isRequired,
        onChange: PropTypes.func.isRequired,

        value: PropTypes.string.isRequired,
        type: PropTypes.string,
        placeholder: PropTypes.string,
        name: PropTypes.string.isRequired,
        text: PropTypes.string.isRequired,
    }

    static defaultProps = {
        type: 'text',
        name: '',
        className: '',
        value: null,
        placeholder: '',
        size: 'small',
        text: '',
    }

    render() {
        const b = block('input')
        const { placeholder, size, type, onChange, name, value, text, onClick } = this.props
        let inputReady;
        switch (type) {
            case 'text':{
                inputReady = (
                    <input 
                        type={type}
                        className={b({size: size})}
                        placeholder={placeholder}
                        onChange={onChange}
                        name={name}
                        value={value}
                    />
                )
                break;
            }
            case 'checkbox':{
                inputReady = (
                    <div className={b('checkbox-container')}>
                        {text}
                        <input 
                            type={type}
                            onClick={onClick}
                            name={name}
                            value={value}
                        />
                    </div>
                )
                break;
            }
            default : {
                inputReady = null;
            }
        }
        return (
            <div className={b('container')}>
                {inputReady}
            </div>
        )
    }
}

export default Input