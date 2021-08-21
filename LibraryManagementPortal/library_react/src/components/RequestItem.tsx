import { Dispatch, SetStateAction } from "react";
import { Link } from "react-router-dom";
import StringFormatter from "../helpers/StringFormatter";
import RequestInterface from "../models/RequestInterface";
import StringResource from "../resources/StringResource";
import APICaller from "../services/APICaller.service";

export default function RequestItem({
    request,
    index,
    isAdmin = false,
    stateChange,
    setTargetId,
    setStateChange,
}: {
    request: RequestInterface;
    index: number;
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

        if (response.status === 200) {
            setStateChange(!stateChange);
        }
    }

    return (
        <tr key={request.id}>
            <th scope="row" className="text-center">
                {isNaN(index) ? 1 : index}
            </th>
            <td>
                <Link to={StringResource.linkAdminUserDetails + request.userId}>
                    {request.user?.username}
                </Link>
            </td>
            {/* <td>
                {!request.books || request.books.length === 0 ? (
                    <p>No book was found in this category</p>
                ) : (
                    request.books!.map((b: Book) => (
                        <Link to={StringResource.linkBookDetails + b.id}>
                            {b.title},{" "}
                        </Link>
                    ))
                )}
            </td> */}
            <td className="text-center">
                {StringFormatter.dateUS(request.requestedDate)}
            </td>
            <td className="text-center">
                {StringFormatter.getRequestStatus(request.status)}
            </td>
            <td className="text-center">
                {isAdmin ? (
                    <>
                        {request.status === 0 ? (
                            <>
                                <button
                                    className="btn btn-success ml-3"
                                    onClick={() =>
                                        changeRequestStatus(request.id, 1)
                                    }
                                >
                                    Approve
                                </button>
                                <button
                                    className="btn btn-danger ml-3"
                                    onClick={() =>
                                        changeRequestStatus(request.id, 2)
                                    }
                                >
                                    Reject
                                </button>
                            </>
                        ) : (
                            <></>
                        )}
                        {request.status === 2 ? (
                            <button
                                type="button"
                                className="btn btn-danger"
                                onClick={() => setTargetId!(request.id)}
                                data-toggle="modal"
                                data-target="#modalDelete"
                            >
                                Delete
                            </button>
                        ) : (
                            <></>
                        )}
                    </>
                ) : (
                    <></>
                )}
            </td>
        </tr>
    );
}
