import { createContext } from "react";

export const defaultContext = {
    username: "",
    role: ""
}

export const AppContext = createContext<{username: string, role: string}>(defaultContext);

export default AppContext