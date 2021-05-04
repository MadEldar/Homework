import axios from "axios";
import APIUrlBuiler from "../helpers/APIUrlBuiler";
import { getAuthToken } from "../helpers/LocalStorageHelper";

axios.interceptors.request.use((config) => {
    const token = getAuthToken();
    config.headers.AuthToken = token;
    
    return config;
});

const APICaller = {
    deleteBook: async (bookId: string) => {
        return await axios({
            method: "delete",
            url: APIUrlBuiler.getAdminBookManagement + bookId,
        }).then((res) => res.data);
    },
    deleteCategory: async (categoryId: string) => {
        return await axios({
            method: "delete",
            url: APIUrlBuiler.getAdminCategoryManagement + categoryId,
        }).then((res) => res.data);
    },
    deleteRequest: async (requestId: string) => {
        return await axios({
            method: "delete",
            url: APIUrlBuiler.getAdminRequestManagement + requestId,
        }).then((res) => res.data);
    },
    deleteUser: async (userId: string) => {
        return await axios({
            method: "delete",
            url: APIUrlBuiler.getAdminUserManagement + userId,
        }).then((res) => res.data);
    },
    getBookById: async (id: string) => {
        return await axios({
            method: "get",
            url: APIUrlBuiler.getBook + id,
        }).then((res) => res.data);
    },
    getBookList: async (page: number = 1, limit: number = 10) => {
        return await axios({
            method: "get",
            url: APIUrlBuiler.getBook + `list?page=${page}&limit=${limit}`,
        }).then((res) => res.data);
    },
    getBooksByIds: async (ids: string[], page: number, limit: number) => {
        return await axios({
            method: "post",
            url: APIUrlBuiler.getBook + `many?page=${page}&limit=${limit}`,
            data: ids,
        }).then((res) => res.data);
    },
    getAllCategories: async () => {
        return await axios({
            method: "get",
            url: APIUrlBuiler.getCategory + "all",
        }).then((res) => res.data);
    },
    getCategoryById: async (id: string) => {
        return await axios({
            method: "get",
            url: APIUrlBuiler.getCategory + id,
        }).then((res) => res.data);
    },
    getCategoryList: async (page: number = 1, limit: number = 10) => {
        return await axios({
            method: "get",
            url: APIUrlBuiler.getCategory + `list?page=${page}&limit=${limit}`,
        }).then((res) => res.data);
    },
    getRequestList: async (page: number = 1, limit: number = 10) => {
        return await axios({
            method: "get",
            url: APIUrlBuiler.getAdminRequestManagement + `list?page=${page}&limit=${limit}`,
        }).then((res) => res.data);
    },
    getUserList: async (page: number = 1, limit: number = 10) => {
        return await axios({
            method: "get",
            url: APIUrlBuiler.getAdminUserManagement + `list?page=${page}&limit=${limit}`,
        }).then((res) => res.data);
    },
    getUserById: async (id: string) => {
        return await axios({
            method: "get",
            url: APIUrlBuiler.getAdminUserManagement + id,
        }).then((res) => res.data);
    },
    getCurrentUser: async () => {
        return await axios({
            url: APIUrlBuiler.currentUser,
            method: "get",
        }).then((res) => res.data);
    },
    getCurrentUserRequests: async () => {
        return await axios({
            url: APIUrlBuiler.currentUserRequests,
            method: "get",
        }).then((res) => res.data);
    },
    postBook: async (form: FormData) => {
        return await axios({
            method: "post",
            url: APIUrlBuiler.getAdminBookManagement,
            data: form,
        }).then((res) => res.data);
    },
    postCategory: async (form: FormData) => {
        return await axios({
            method: "post",
            url: APIUrlBuiler.getAdminCategoryManagement,
            data: form,
        }).then((res) => res.data);
    },
    postLogin: async (form: FormData) => {
        // Send request without AuthToken header interceptor
        return await axios.create()({
            method: "post",
            url: APIUrlBuiler.login,
            data: form,
        }).then((res) => res.data);
    },
    postRequest: async (ids: string[]) => {
        return await axios({
            method: "post",
            url: APIUrlBuiler.requestBook,
            data: ids,
        }).then((res) => res.data);
    },
    putBook: async (form: FormData) => {
        return await axios({
            method: "put",
            url: APIUrlBuiler.getAdminBookManagement + `${form.get("id")}`,
            data: form,
        }).then((res) => res.data);
    },
    putRequestStatus: async (requestId: string, status: number) => {
        return await axios({
            method: "put",
            url: APIUrlBuiler.getAdminRequestManagement + `${requestId}?status=${status}`,
        }).then((res) => res.data);
    }
};

export default APICaller;
