import vacancyApiModel from '../api/'

const actionTypes = {
    LOAD_VACANCIES: 'LOAD_VACANCIES',
    LOAD_TEST_VACANCIES: 'LOAD_TEST_VACANCIES',
    LOAD_VACANCIES_SUCCESS: 'LOAD_VACANCIES_SUCCESS',
    ADD_VACANCY: 'ADD_VACANCY',
}

function addVacancy(vacancy) {
    return dispatch => {
    return vacancyApiModel.save(vacancy).then(returnedVacancy => {
        dispatch(loadAllVacancies())
    });
}
}

function loadUserVacancies(userId) {

    //TODO:Тут нужно написать запрос, который в переменную userVacancies загрузит все вакансии, принадлежащие мэнеджеру с userId
    const userVacancies = []

    return {
        type: actionTypes.LOAD_VACANCIES_SUCCESS,
        payload: userVacancies,
    }
}

function loadAllVacancies() {
    return (dispatch) => {
        return vacancyApiModel.get().then(allVacancies => {
                console.log(allVacancies)
                dispatch({type: actionTypes.LOAD_VACANCIES_SUCCESS,
                payload: allVacancies.data})
    });
}
}

// const loadAllVacancies = () => dispatch => {
//     setTimeout(() => {
//         dispatch({type:actionTypes.LOAD_VACANCIES_SUCCESS, payload: [1, 2]})
//     }, 2000);
// }

function loadTestVacancies() {
    return {
        type: actionTypes.LOAD_TEST_VACANCIES,
        payload: {},
    }
}

export {
    actionTypes,
    loadUserVacancies,
    loadTestVacancies,
    loadAllVacancies,
    addVacancy
}