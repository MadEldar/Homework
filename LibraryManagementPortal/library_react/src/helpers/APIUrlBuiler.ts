const baseUrl = process.env.REACT_APP_API_BASE_URL;

const APIUrlBuiler = {
    currentUser: `${baseUrl}user/`,
    currentUserRequests: `${baseUrl}user/requests/`,
    getAdminBookManagement: `${baseUrl}admin/bookmanagement/`,
    getAdminCategoryManagement: `${baseUrl}admin/categorymanagement/`,
    getBook: `${baseUrl}book/`,
    getCategory: `${baseUrl}category/`,
    requestBook: `${baseUrl}user/request-books/`,
    login: `${baseUrl}login/`,
};

export default APIUrlBuiler;