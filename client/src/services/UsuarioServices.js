class UsuarioService {
    axios
    baseUrl

    constructor(axios,url) {
        this.axios = axios
        this.baseUrl = url + 'Usuario'
    }

    getAll() {
        let self = this;
        return self.axios.get(`${self.baseUrl}`);
    }

    getOne(id) {
        let self = this;
        return self.axios.get(`${self.baseUrl}/${id}`);
    }

    save(model) {
        let self = this;
        return self.axios.post(`${self.baseUrl}`, model);
    }

    update(model) {
        let self = this;
        return self.axios.put(`${self.baseUrl}`, model);
    }

    delete(id) {
        let self = this;
        return self.axios.delete(`${self.baseUrl}/${id}`);
    }

}

export default UsuarioService