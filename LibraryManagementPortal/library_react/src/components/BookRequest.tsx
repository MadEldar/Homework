import { useEffect, useState } from "react";
import Book from "../models/Book";
import RequestInterface from "../models/RequestInterface";
import APICaller from "../services/APICaller.service";

export function BookRequest() {
    const [requests, setRequests] = useState<RequestInterface[]>([]);

    useEffect(() => {
        (async () => {
            const currentUserRequests: RequestInterface[] = await APICaller.getCurrentUserRequests();

            setRequests(currentUserRequests);
        })();
    }, []);

    return (
        <div className="container">
            <div className="row">
                <h3 className="col-12 my-3">Past requests</h3>
                {requests.map((r: RequestInterface) => (
                    <div className="col-sm-6" key={r.id}>
                        <div className="card">
                            <div className="card-header">
                                <h5 className="card-title">
                                    {new Date(Date.parse(r.requestedDate)).toLocaleString("en-US")}
                                </h5>
                            </div>
                            <div className="card-body">
                                <div className="row">
                                    {r.books?.map((b: Book) => (
                                        <div className="col-12 my-2" key={b.id}>
                                            <h5>{b.title}</h5>
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
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
}
