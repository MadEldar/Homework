import { Dispatch, SetStateAction } from "react";
import { Link } from "react-router-dom";
import StringFormatter from "../helpers/StringFormatter";
import Book from "../models/Book";
import RequestInterface from "../models/RequestInterface";
import StringResource from "../resources/StringResource";
import APICaller from "../services/APICaller.service";

export default function RequestCardItem({
    requests,
    isAdmin,
    stateChange,
    setStateChange,
    setTargetId,
}: {
    requests: RequestInterface[];
    isAdmin: boolean;
    stateChange: boolean;
    setStateChange: Dispatch<SetStateAction<boolean>>;
    setTargetId?: Dispatch<SetStateAction<string>>;
}) {
    async function changeRequestStatus(requestId: string, toStatus: number) {
        const response = await APICaller.putRequestStatus(
            requestId,
            toStatus
        ).then();

        if (response.statusCode === 200) {
            setStateChange(!stateChange);
        }
    }

    return (
        <div className="container">
            <div className="row">
                <h3 className="col-12 my-3">Past requests</h3>
                {requests.map((r: RequestInterface) => (
                    <div className="col-sm-6 my-3" key={r.id}>
                        <div className="card">
                            <div
                                className={`card-header ${
                                    r.status === 0
                                        ? ""
                                        : r.status === 1
                                        ? "badge-success"
                                        : "badge-danger"
                                }`}
                            >
                                <h5 className="card-title">
                                    {StringFormatter.dateUS(r.requestedDate)}
                                    <span className="float-right">
                                        {StringFormatter.getRequestStatus(
                                            r.status
                                        )}
                                    </span>
                                </h5>
                            </div>
                            <div className="card-body">
                                <div className="row">
                                    {r.books?.map((b: Book) => (
                                        <div className="col-12 my-2" key={b.id}>
                                            <h5>
                                                <Link
                                                    to={
                                                        StringResource.linkAdminBookDetails +
                                                        b.id
                                                    }
                                                >
                                                    {b.title}
                                                </Link>
                                            </h5>
                                            <p>
                                                <span className="float-left">
                                                    {b.author}
                                                </span>
                                                <span className="float-right">
                                                    {b.category?.name}
                                                </span>
                                            </p>
                                        </div>
                                    ))}
                                </div>
                            </div>
                            {isAdmin && r.status === 0 ? (
                                <div className="card-footer">
                                    <div className="row">
                                        <>
                                            <button
                                                className="btn btn-success ml-2"
                                                onClick={() =>
                                                    changeRequestStatus(r.id, 1)
                                                }
                                            >
                                                Approve
                                            </button>
                                            <button
                                                className="btn btn-danger ml-2"
                                                onClick={() =>
                                                    changeRequestStatus(r.id, 2)
                                                }
                                            >
                                                Reject
                                            </button>
                                        </>
                                    </div>
                                </div>
                            ) : (
                                <>
                                    {isAdmin && r.status === 2 ? (
                                        <div className="card-footer">
                                            <div className="row">
                                                <button
                                                    type="button"
                                                    className="btn btn-danger ml-2"
                                                    onClick={() =>
                                                        setTargetId!(r.id)
                                                    }
                                                    data-toggle="modal"
                                                    data-target="#modalDelete"
                                                >
                                                    Delete
                                                </button>
                                            </div>
                                        </div>
                                    ) : (
                                        <></>
                                    )}
                                </>
                            )}
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
}
