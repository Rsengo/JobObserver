import React from 'react'
import { Component } from 'react'
import { block } from 'bem-cn'

import './Profile.styl'

class Profile extends Component {
    render() {
        const b = block('profile')
        const {user} = this.props
        return (
            <div className={b()}>
                <div className={b('row')}>Имя: {user.first_name}</div>
                <div className={b('row')}>Фамилия: {user.last_name}</div>
                <div className={b('row')}>Дата рождения: {user.birth_date}</div>
                <div className={b('row')}>Пол: {user.gender}</div>
                <div className={b('row')}>Место жительства: {user.area}</div>
            </div>
        )
    }
}

export default Profile