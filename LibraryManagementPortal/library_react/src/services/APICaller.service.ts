import axios from "axios";
import APIUrlBuiler from "../helpers/APIUrlBuiler";
import { getAuthToken } from "../helpers/AuthTokenHelper";

const APICaller = {
    login: async (form: FormData) => {
        return await axios({
            method: "post",
            url: APIUrlBuiler.login,
            data: form,
        }).then();
    },
    getBooks: async (page: number = 1, limit: number = 10) => {
        return await axios({
            method: "get",
            url: APIUrlBuiler.getBooks + `?page=${page}&limit=${limit}`,
            headers: {
                AuthToken: getAuthToken(),
            },
        }).then((res) => res.data);
    },
    getCategories: async (page: number = 1, limit: number = 10) => {
        return await axios({
            method: "get",
            url: APIUrlBuiler.getCategories + `?page=${page}&limit=${limit}`,
            headers: {
                AuthToken: getAuthToken(),
            },
        }).then((res) => res.data);
    },
    getCurrentUser: async () => {
        return await axios({
            url: APIUrlBuiler.currentUser,
            method: "get",
            headers: {
                AuthToken: getAuthToken(),
            },
        }).then((res) => res.data);
    },
    getCurrentUserRequests: async () => {
        return await axios({
            url: APIUrlBuiler.currentUserRequests,
            method: "get",
            headers: {
                AuthToken: getAuthToken(),
            },
        }).then((res) => res.data);
    },
};

export default APICaller;
