import React from 'react'
import { Component } from 'react'
import { block } from 'bem-cn'

import { dictionary } from '../redux/data/dictionary'

import './Footer.styl'

class Footer extends Component {
    render() {
        const b = block('footer')
        return(
            <div className={b()}>
                <div className={b('contacts')}>
                    <div className={b('number-text')}>
                        {dictionary.phone} :
                    </div>
                    <div className={b('number-phone')}>
                        8-800-555-3535
                    </div>
                </div>
                <div className={b('email')}>
                    <div className={b('email-text')}>
                        {dictionary.email} :
                    </div>
                    <div className={b('email-value')}>
                        evgdanrom@gmail.com
                    </div>
                </div>
                <div className={b('technology')}>
                    <div className={b('tech-text')}>
                        {dictionary.tech} :
                    </div>
                    <div className={b('tech-value')}>
                        Asp.Net Core, RabbitMQ, Entity Framework Core, React, Redux
                    </div>
                </div>
            </div>
        )
    }
}

export default Footer