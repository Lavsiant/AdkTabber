import { combineReducers } from 'redux'
import { History } from 'history'
import { connectRouter } from 'connected-react-router'
import { authReducer } from '../components/auth/authReducer'

const rootReducer = (history: History) => combineReducers({
    authReducer,
    router: connectRouter(history)
})

export default rootReducer;