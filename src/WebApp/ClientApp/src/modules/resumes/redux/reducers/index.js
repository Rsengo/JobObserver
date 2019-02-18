import { actionTypes } from '../actions/index'

const initialState = {
    resumes: [],
}

function reducer(state = initialState, action) {
    switch (action.type) {

        case actionTypes.LOAD_RESUMES_SUCCESS: {
            console.log(action.payload)
            return {...state, resumes: action.payload}
        }

        default: {
            return {...state};
        }
    }
}

export { reducer }