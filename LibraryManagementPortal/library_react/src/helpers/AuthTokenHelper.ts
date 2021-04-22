import StringResource from "../resources/StringResource";

export const setAuthToken = (token: string) => {
    const tokenConfig = {
        value: token,
        expiration: new Date().getTime() + 7200000,
    };

    localStorage.setItem(StringResource.token, JSON.stringify(tokenConfig));
}

export const getAuthToken = () => {
    const token = localStorage.getItem(StringResource.token);

    if (token) {
        const tokenObject = JSON.parse(token);

        if (tokenObject.expiration > new Date().getTime()) {
            return tokenObject.value;
        }
    }
    
    logout();
};

export const logout = () => {
    localStorage.removeItem(StringResource.token);
    localStorage.removeItem(StringResource.admin);

    window.location.href = StringResource.linkLogin;
}

export default {
    getAuthToken,
    setAuthToken
}