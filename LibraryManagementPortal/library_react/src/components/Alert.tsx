import { useEffect } from "react";
import AlertMessage from "../models/AlertMessage";

export default function Alert({ message, type, statusCode }: AlertMessage) {
    useEffect(() => {
        
    });
    return (
        <>
            <div
                className={message === "" ? "" : `alert alert-${type} alert-dismissible fade show`}
                role="alert"
            >
                <span><strong>{statusCode ?? <>{statusCode}</>}</strong> {message}</span>
                <button
                    type="button"
                    className="close"
                    data-dismiss="alert"
                    aria-label="Close"
                >
                    <span className={message !== "" ? "" : "d-none"} aria-hidden="true">&times;</span>
                </button>
            </div>
        </>
    );
}
