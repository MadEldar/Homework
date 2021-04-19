import { createContext, useContext, Dispatch, SetStateAction } from "react";

export const AppContext = createContext({});

// const { token, setToken } = useContext(AppContext) as {
//     token: string,
//     setToken: Dispatch<SetStateAction<string>>
// }

export default AppContext;