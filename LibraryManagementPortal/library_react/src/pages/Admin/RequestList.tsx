import { useEffect, useState } from "react";
import { useHistory, useLocation } from "react-router-dom";
import ConfirmModal from "../../components/ConfirmModal";
import Pagination from "../../components/Pagination";
import RequestItem from "../../components/RequestItem";
import ParamBuilder from "../../helpers/ParamBuilder";
import PaginationInfo from "../../models/PaginationInfo";
import RequestInterface from "../../models/RequestInterface";
import APICaller from "../../services/APICaller.service";

export default function AdminRequestList({
    initRequests,
}: {
    initRequests?: RequestInterface[];
}) {
    const history = useHistory();
    const pathname = history.location.pathname;
    const [stateChange, setStateChange] = useState(false);
    const [requests, setRequests] = useState<RequestInterface[]>(
        initRequests ?? []
    );
    const [pagination, setPagination] = useState<PaginationInfo>({
        link: pathname,
        page: 1,
        limit: 10,
        totalPage: 1,
    });

    const query = new URLSearchParams(useLocation().search);
    const page = Number.parseInt(query.get("page")!) || 1;
    const limit = Number.parseInt(query.get("limit")!) || 10;

    const hasRequests = initRequests && initRequests.length > 0;
    const [deleteTargetId, setDeleteTargetId] = useState("");

    function deleteRequest() {
        (async () => {
            const result = await APICaller.deleteRequest(deleteTargetId).then();

            if (result.statusCode === 200) {
                setRequests(requests.filter((r) => r.id !== deleteTargetId));
            }
        })();
    }

    if (!hasRequests && (!query.get("page") || !query.get("limit"))) {
        history.replace({
            pathname: pathname,
            search: ParamBuilder({
                page: "1",
                limit: "10",
            }),
        });
    }

    useEffect(() => {
        (async () => {
            if (!hasRequests) {
                setRequests([]);

                const requestData = await APICaller.getRequestList().then();

                setRequests(requestData.requests);

                var totalPage = Math.ceil(
                    requestData.totalCategories / requestData.limit
                );

                console.log(requestData);

                setPagination({
                    link: pathname,
                    page: requestData.page,
                    limit: requestData.limit,
                    totalPage: totalPage,
                });
            }
        })();
    }, [page, limit, pathname, stateChange]);

    let indexIncrement = (page - 1) * limit;

    return (
        <>
            <div className="container mt-4">
                <div className="row">
                    <h2 className="col-12 text-center">Request list</h2>
                    <table className="table table-striped mt-5">
                        <thead>
                            <tr>
                                <th scope="col" className="text-center">
                                    #
                                </th>
                                <th scope="col" className="text-center">
                                    Username
                                </th>
                                {/* <th scope="col" className="text-center">Books</th> */}
                                <th scope="col" className="text-center">
                                    Request date
                                </th>
                                <th scope="col" className="text-center">
                                    Status
                                </th>
                                <th scope="col" className="text-center">
                                    Action
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            {requests.map((r) => (
                                <RequestItem
                                    stateChange={stateChange}
                                    setStateChange={setStateChange}
                                    request={r}
                                    index={++indexIncrement}
                                    key={r.id}
                                    isAdmin={true}
                                    setTargetId={setDeleteTargetId}
                                />
                            ))}
                        </tbody>
                    </table>
                    {!hasRequests ? <Pagination {...pagination} /> : <></>}
                </div>
            </div>

            <ConfirmModal
                id="modalDelete"
                action="delete"
                confirmMessage="Are you sure you want to delete this request?"
                title="Delete request"
                handleConfirm={deleteRequest}
                targetId={deleteTargetId}
            />
        </>
    );
}
