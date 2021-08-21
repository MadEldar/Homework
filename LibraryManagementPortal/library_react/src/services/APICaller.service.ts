import axios from "axios";
import APIUrlBuiler from "../helpers/APIUrlBuiler";
import { getAuthToken } from "../helpers/LocalStorageHelper";
import Book from "../models/Book";

axios.interceptors.request.use((config) => {
    const token = getAuthToken();
    config.headers.AuthToken = token;

    return config;
});

const APICaller = {
    deleteBook: async (bookId: string) => {
        return axios({
            method: "delete",
            url: APIUrlBuiler.getAdminBookManagement + bookId,
        });
    },
    deleteCategory: async (categoryId: string) => {
        return axios({
            method: "delete",
            url: APIUrlBuiler.getAdminCategoryManagement + categoryId,
        });
    },
    deleteRequest: async (requestId: string) => {
        return axios({
            method: "delete",
            url: APIUrlBuiler.getAdminRequestManagement + requestId,
        });
    },
    deleteUser: async (userId: string) => {
        return axios({
            method: "delete",
            url: APIUrlBuiler.getAdminUserManagement + userId,
        });
    },
    getBookById: async (id: string) => {
        return axios({
            method: "get",
            url: APIUrlBuiler.getBook + id,
        });
    },
    getBookList: async (page: number = 1, limit: number = 10) => {
        return axios({
            method: "get",
            url: APIUrlBuiler.getBook + `list?page=${page}&limit=${limit}`,
        });
    },
    getBooksByIds: async (ids: string[], page: number, limit: number) => {
        return axios({
            method: "post",
            url: APIUrlBuiler.getBook + `many?page=${page}&limit=${limit}`,
            data: ids,
        });
    },
    getAllCategories: async () => {
        return axios({
            method: "get",
            url: APIUrlBuiler.getCategory + "all",
        });
    },
    getCategoryById: async (id: string) => {
        return axios({
            method: "get",
            url: APIUrlBuiler.getCategory + id,
        });
    },
    getCategoryList: async (page: number = 1, limit: number = 10) => {
        return axios({
            method: "get",
            url: APIUrlBuiler.getCategory + `list?page=${page}&limit=${limit}`,
        });
    },
    getRequestList: async (page: number = 1, limit: number = 10) => {
        return axios({
            method: "get",
            url:
                APIUrlBuiler.getAdminRequestManagement +
                `list?page=${page}&limit=${limit}`,
        });
    },
    getUserList: async (page: number = 1, limit: number = 10) => {
        return axios({
            method: "get",
            url:
                APIUrlBuiler.getAdminUserManagement +
                `list?page=${page}&limit=${limit}`,
        });
    },
    getUserById: async (id: string) => {
        return axios({
            method: "get",
            url: APIUrlBuiler.getAdminUserManagement + id,
        });
    },
    getCurrentUser: async () => {
        return axios({
            url: APIUrlBuiler.currentUser,
            method: "get",
        });
    },
    getCurrentUserRequests: async () => {
        return axios({
            url: APIUrlBuiler.currentUserRequests,
            method: "get",
        });
    },
    postBook: async (book: Book) => {
        const { author, title, categoryId } = book;
        return axios({
            method: "post",
            url: APIUrlBuiler.getAdminBookManagement,
            data: { author, title, categoryId },
        });
    },
    postCategory: async (name: string) => {
        return axios({
            method: "post",
            url: APIUrlBuiler.getAdminCategoryManagement,
            data: { name },
        });
    },
    postLogin: async (form: FormData) => {
        // Send request without AuthToken header interceptor
        return axios.create()({
            method: "post",
            url: APIUrlBuiler.login,
            data: form,
        });
    },
    postRequest: async (ids: string[]) => {
        return axios({
            method: "post",
            url: APIUrlBuiler.requestBook,
            data: ids,
        });
    },
    putBook: async (form: FormData) => {
        return axios({
            method: "put",
            url: APIUrlBuiler.getAdminBookManagement + `${form.get("id")}`,
            data: form,
        });
    },
    putRequestStatus: async (requestId: string, status: number) => {
        return axios({
            method: "put",
            url:
                APIUrlBuiler.getAdminRequestManagement +
                `${requestId}?status=${status}`,
        });
    },
};

export default APICaller;
