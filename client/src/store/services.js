import Axios from 'axios'
import exampleService from '../services/ExampleService'
import LoginService from '../services/LoginService'
import UsuarioService from '../services/UsuarioServices'

let apiUrl = 'http://localhost:64550/'

// Axios Configuration
Axios.defaults.headers.common.Accept = 'application/json'

export default {
    exampleService: new exampleService(Axios),
    LoginService: new LoginService(Axios,apiUrl),
    UsuarioService: new UsuarioService(Axios,apiUrl)
}