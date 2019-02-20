import {actionTypes} from '../actions'
import { AuthTypes } from  '../data/types'

const initialState ={
    isAuth: false,
    user: {},
    role: null,
    isOpenAuthModal: false,
    isOpenRegMadal: false,
}

function reducer(state = initialState, action)
{
    switch(action.type) {

        case actionTypes.SIGN_IN_UN:
            const newUser1 = {
                id: 1,
                last_name: 'Чубик',
                first_name: 'Петр',
                birth_date: '10.07.1958',
                gender: 'Male',
                area: 'Russia, Tomsk',
            }    
            return {...state, isAuth: true, user: newUser1, role: AuthTypes.UN}

        case actionTypes.SIGN_IN_COMP:
            const newUser2 = {
                id: 2,
                last_name: 'Гейтс',
                first_name: 'Билл',
                birth_date: '10.07.1968',
                gender: 'Male',
                area: 'USA, California',
            }    
            return {...state, isAuth: true, user: newUser2, role: AuthTypes.COMP}    

        case actionTypes.SIGN_IN_APP:
            const newUser3 = {
                id: 3,
                last_name: 'Немнов',
                first_name: 'Роман',
                birth_date: '10.07.1968',
                gender: 'Male',
                area: 'Russia, Tomsk',
            }    
            return {...state, isAuth: true, user: newUser3, role: AuthTypes.APP}              

        case actionTypes.SIGN_UP:
            return state
            
        case actionTypes.LOG_OUT:
            return {...state, isAuth: false, user: {}, role: null} 
            
        case actionTypes.SWITCH_VIEW_AUTH_MODAL:
            return { ...state, isOpenAuthModal: action.payload }    

        case actionTypes.SWITCH_VIEW_REG_MODAL:
            return { ...state, isOpenRegModal: action.payload }     

        default:
            return state;    
    }
}

export  { reducer }