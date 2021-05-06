import StringResource from "../resources/StringResource";

export const getAuthToken = () => {
    const token = localStorage.getItem(StringResource.token);

    if (token) {
        const tokenObject: {
            value: string;
            expiration: number;
        } = JSON.parse(token);

        if (tokenObject.expiration > new Date().getTime()) {
            setAuthToken(tokenObject.value);
            return tokenObject.value;
        }
    }

    logout();
};

export const setAuthToken = (token: string) => {
    const tokenConfig = {
        value: token,
        expiration: new Date().getTime() + 7200000,
    };

    localStorage.setItem(StringResource.token, JSON.stringify(tokenConfig));
};

export const getSavedBookIds = (): string[] => {
    const storageIds = localStorage.getItem(StringResource.requestedBookIds);

    if (!storageIds || storageIds === "") return [];
    else return storageIds.split("&");
};

export const saveBookIds = (id: string) => {
    const storageIds = getSavedBookIds();

    storageIds.push(id);

    localStorage.setItem(StringResource.requestedBookIds, storageIds.join("&"));
};

export const removeSavedBookIds = (id: string) => {
    const storageIds = getSavedBookIds();

    localStorage.setItem(
        StringResource.requestedBookIds,
        storageIds.filter((sId) => sId !== id).join("&")
    );
};

export const logout = () => {
    localStorage.removeItem(StringResource.token);
    localStorage.removeItem(StringResource.admin);
    localStorage.removeItem(StringResource.requestedBookIds);

    window.location.href = StringResource.linkLogin;
};

const LocalStorageHelper = {
    getAuthToken,
    setAuthToken,
    logout,
    getSavedBookIds,
    saveBookIds,
    removeSavedBookIds,
};

export default LocalStorageHelper;
