const baseUrl = process.env.REACT_APP_API_BASE_URL;

const APIUrlBuiler = {
    login: `${baseUrl}login`,
    currentUser: `${baseUrl}user`,
    currentUserRequests: `${baseUrl}user/requests`,
    getAdminAllCategories: `${baseUrl}admin/categorymanagement/all`,
    getAdminBookManagement: `${baseUrl}admin/bookmanagement`,
    getBooks: `${baseUrl}book`,
    getCategories: `${baseUrl}category`,
};

export default APIUrlBuiler;