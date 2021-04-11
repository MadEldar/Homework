import { createContext, useReducer } from "react";

const initialState = {
    notification: {
        message: "You did it!!!",
        type: "success",
    },
};
const store = createContext(initialState);
const { Provider } = store;

const StateProvider = ({ children }: { children: any }) => {
    const [state, dispatch] = useReducer((state: any, action: any) => {
        console.log(state);
        console.log(action);
        switch (action.type) {
            case "action description":
                console.log(state);
                console.log(action);
                return state;
            case "bound dispatchAction":
                console.log(state);
                console.log(action);
                return {
                    notification: {
                        message: "",
                        type: ""
                    }
                }
            default:
                throw new Error();
        }
    }, initialState);

    return <Provider value={{ ...state, dispatch }}>{children}</Provider>;
};

export { store, StateProvider };
