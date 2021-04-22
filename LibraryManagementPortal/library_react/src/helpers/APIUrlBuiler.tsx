export default {
    login: `${process.env.REACT_APP_API_BASE_URL}login`,
    currentUser: `${process.env.REACT_APP_API_BASE_URL}user`,
    currentUserRequests: `${process.env.REACT_APP_API_BASE_URL}user/requests`,
    getBooks: `${process.env.REACT_APP_API_BASE_URL}book`,
    getCategories: `${process.env.REACT_APP_API_BASE_URL}category`,
};