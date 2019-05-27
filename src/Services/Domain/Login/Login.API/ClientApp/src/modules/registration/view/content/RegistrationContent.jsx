import React from 'react';
import { Component } from 'react'
import AsyncMaterialSelect from '../../../../elements/autocomplete/AsyncMaterialSelect'
import MaterialSelect from '../../../../elements/autocomplete/MaterialSelect'
import { block } from 'bem-cn'
import { bind } from 'decko'
import { Visibility, VisibilityOff } from '@material-ui/icons'
import { 
    TextField, 
    InputAdornment, 
    IconButton
} from '@material-ui/core'
import roles from '../../../../settings/roles'

import './RegistrationContent.styl'

const rolesOptions = Object.values(roles).map(role => { 
  return {
    label: role.name, 
    value: role.id
  }
});

class RegistrationContent extends Component {
    constructor(props) {
        super(props);

        this.state = {
            showPassword: false,
            showPasswordConfirm: false,
            role: roles.APPLICANT.id
        };
    }

    @bind
    handleClickShowPassword() {
      this.setState({ ...this.state, showPassword: !this.state.showPassword });
    };

    render() {
        const { callback } = this.props

        var b = block('registration_content')
        return (
            <div className={b()}>
                <MaterialSelect
                    options={rolesOptions}
                    label='Роль'
                    name='role'
                    placeholder='Выберите роль'
                    value={rolesOptions[0]}
                    InputLabelProps={{
                      shrink: true,
                    }}
                    onChange={callback} />

                <TextField
                    id='email-input'
                    label='Email'
                    type='email'
                    name='email'
                    required={true}
                    autoComplete='email'
                    margin='normal'
                    onChange={callback}
                    InputLabelProps={{
                      shrink: true,
                    }}/>

                <TextField
                    id='password-input'
                    label='Пароль'
                    type={this.state.showPassword ? 'text' : 'password'}
                    name = 'password'
                    required={true}
                    autoComplete='current-password'
                    margin='normal'
                    onChange={callback}
                    InputProps={{
                        endAdornment: (
                          <InputAdornment position="end">
                            <IconButton
                              aria-label="Toggle password visibility"
                              onClick={this.handleClickShowPassword}
                            >
                              {this.state.showPassword ? <VisibilityOff /> : <Visibility />}
                            </IconButton>
                          </InputAdornment>
                        )}} 
                    InputLabelProps={{
                      shrink: true,
                    }}/>

                <TextField
                    id='password-confirm-input'
                    label='Подтверждение пароля'
                    type={this.state.showPasswordConfirm ? 'text' : 'password'}
                    name = 'confirm_password'
                    autoComplete='confirm-current-password'
                    margin='normal'
                    required={true}
                    onChange={callback}
                    InputProps={{
                        endAdornment: (
                          <InputAdornment position="end">
                            <IconButton
                              aria-label="Toggle password visibility"
                              onClick={this.handleClickShowPassword}
                            >
                              {this.state.showPassword ? <VisibilityOff /> : <Visibility />}
                            </IconButton>
                          </InputAdornment>
                        )}} 
                    InputLabelProps={{
                      shrink: true,
                    }}/>

                <TextField
                    id='first-name-input'
                    label='Имя'
                    type='text'
                    name='first_name'
                    required={true}
                    margin='normal'
                    onChange={callback}
                    InputLabelProps={{
                      shrink: true,
                    }}/>

                <TextField
                    id='last-name-input'
                    label='Фамилия'
                    type='text'
                    name='last_name'
                    required={true}
                    margin='normal'
                    onChange={callback}
                    InputLabelProps={{
                      shrink: true,
                    }}/>

                  <TextField
                    id='birth-date-name-input'
                    label='Дата рождения'
                    type='date'
                    name='birth_date'
                    required={true}
                    margin='normal'
                    onChange={callback}
                    InputLabelProps={{
                      shrink: true,
                    }}/>

                    <AsyncMaterialSelect 
                      label='Место проживания'
                      name='area_id'
                      placeholder='Выберите город'
                      InputLabelProps={{
                        shrink: true,
                      }}
                      onChange={callback}/>
            </div>
        )
    }
}

export default RegistrationContent