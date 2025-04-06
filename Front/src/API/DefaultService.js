import axios from "axios";

export default class DefaultService {
    static async getAll(limit=15, page=1, filterValue) {
        const response = await axios.post('https://localhost:7169/api/v1/Default/GetDefault',
            {page: page, limit: limit, filterValue: filterValue});
        return response;
    }

    static async sendValue(code, value) {
        const response = await axios.post('https://localhost:7169/api/v1/Default/CreateDefault',
            [{code: code, value: value}]);
        return response;
    }
}