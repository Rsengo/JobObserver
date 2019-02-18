import { combineReducers } from 'redux'
import { reducer as authReducer} from '../features/auth/redux/reducers'
import {reducer as vacancyReducer} from '../modules/vacancies/redux/reducers'
import { reducer as resumeReducer } from '../modules/resumes/redux/reducers'

export const rootReducer = combineReducers({
    auth: authReducer,
    vacancies: vacancyReducer,
    resumes: resumeReducer,
})