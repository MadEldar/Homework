const APIUrlBuiler = {
    login: `${process.env.REACT_APP_API_BASE_URL}login`,
    currentUser: `${process.env.REACT_APP_API_BASE_URL}user`,
    currentUserRequests: `${process.env.REACT_APP_API_BASE_URL}user/requests`
};

export default APIUrlBuiler;