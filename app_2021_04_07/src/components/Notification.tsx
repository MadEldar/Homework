import { store, StateProvider } from "../Store";
import { useContext, useEffect, useState } from "react";

export function Notification() {
    const [state, dispatch] = useState(store);

    const { Provider, Consumer } = state;

    useEffect(() => {
        console.log("1");
        // dispatch(pre => {return {...pre, notification: {type: "success", message: "You did it!!!"}}});
    }, []);

    function dismissMessage() {
        dispatch((pre) => {
            console.log(pre);
            return {
                ...pre,
                notification: { type: "success", message: "You did it!!!" },
            };
        });
        <Provider
            value={{ notification: { type: "", message: "" } }}
        ></Provider>;
    }

    return (
        <>
        <StateProvider>
        <Consumer>
            {({ notification }) => (
                <div className={`alert alert-${notification.type}`}>
                    <button
                        className="close"
                        type="button"
                        onClick={dismissMessage}
                    >
                        &times;
                    </button>
                    {notification.message}
                </div>
            )}
        </Consumer>
        </StateProvider>
        </>
    );
}
