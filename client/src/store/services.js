import Axios from 'axios'
import exampleService from '../services/ExampleService'

let apiUrl = 'http://localhost:64550/'

// Axios Configuration
Axios.defaults.headers.common.Accept = 'application/json'

export default {
    exampleService: new exampleService(Axios)
}