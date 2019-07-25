class LoginService {
    axios
    baseUrl

    constructor(axios,url) {
        this.axios = axios
        this.baseUrl = url + 'Login'
    }

    getAll() {
        let self = this;
        return self.axios.get(`${self.baseUrl}`);
    }


}

export default LoginService