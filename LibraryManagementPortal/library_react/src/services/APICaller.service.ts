import axios from "axios";
import APIUrlBuiler from "../helpers/APIUrlBuiler";
import { getAuthToken } from "../helpers/AuthTokenHelper";

const APICaller = {
    getAdminAllCategories: async () => {
        return await axios({
            method: "get",
            url: APIUrlBuiler.getAdminAllCategories,
            headers: {
                AuthToken: getAuthToken(),
            },
        }).then((res) => res.data);
    },
    getAdminBookById: async (id: string) => {
        return await axios({
            method: "get",
            url: APIUrlBuiler.getAdminBookManagement + `/${id}`,
            headers: {
                AuthToken: getAuthToken(),
            },
        }).then((res) => res.data);
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
    postLogin: async (form: FormData) => {
        return await axios({
            method: "post",
            url: APIUrlBuiler.login,
            data: form,
        }).then();
    },
    postBook: async (form: FormData) => {
        return await axios({
            method: "post",
            url: APIUrlBuiler.getAdminBookManagement,
            data: form,
            headers: {
                AuthToken: getAuthToken(),
            },
        }).then();
    },
    putBook: async (form: FormData) => {
        console.log(form.get("id"));
        return await axios({
            method: "put",
            url: APIUrlBuiler.getAdminBookManagement + `/${form.get("id")}`,
            data: form,
            headers: {
                AuthToken: getAuthToken(),
            },
        }).then();
    },
};

export default APICaller;
