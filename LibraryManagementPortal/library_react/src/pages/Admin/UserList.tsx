import { useEffect, useState } from "react";
import { useHistory } from "react-router";
import { Link, useLocation } from "react-router-dom";
import UserItem from "../../components/UserItem";
import ConfirmModal from "../../components/ConfirmModal";
import Pagination from "../../components/Pagination";
import ParamBuilder from "../../helpers/ParamBuilder";
import User from "../../models/User";
import PaginationInfo from "../../models/PaginationInfo";
import StringResource from "../../resources/StringResource";
import APICaller from "../../services/APICaller.service";

export default function AdminUserList() {
    const history = useHistory();
    const pathname = history.location.pathname;
    const [users, setUsers] = useState<User[]>([]);
    const [pagination, setPagination] = useState<PaginationInfo>({
        link: pathname,
        page: 1,
        limit: 10,
        totalPage: 1,
    });
    const [deleteTargetId, setDeleteTargetId] = useState("");

    function deleteUser() {
        (async () => {
            const result = await APICaller.deleteUser(deleteTargetId).then();

            if (result.statusCode === 200) {
                setUsers(users.filter((b) => b.id !== deleteTargetId));
            }
        })();
    }

    let query = new URLSearchParams(useLocation().search);

    if (!query.get("page") || !query.get("limit")) {
        history.replace({
            pathname: pathname,
            search: ParamBuilder({
                page: "1",
                limit: "10",
            }),
        });
    }

    const page = Number.parseInt(query.get("page")!) || 1;
    const limit = Number.parseInt(query.get("limit")!) || 10;

    useEffect(() => {
        (async () => {
            setUsers([]);

            const usersData: {
                users: User[];
                totalUsers: number;
                page: number;
                limit: number;
            } = await APICaller.getUserList(page, limit);

            setUsers(usersData.users);

            var totalPage = Math.ceil(usersData.totalUsers / usersData.limit);

            setPagination({
                link: pathname,
                page: usersData.page,
                limit: usersData.limit,
                totalPage: totalPage,
            });
        })();
    }, [page, limit, pathname]);

    let indexIncrement = (page - 1) * limit;

    return (
        <>
            <div className="container mt-4">
                <div className="row">
                    <h2 className="col-8 offset-2 text-center">User List</h2>
                    <Link
                        to={StringResource.linkAdminUserCreate}
                        className="col-2 btn btn-primary"
                    >
                        Create new user
                    </Link>
                    <table className="table table-striped mt-5">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Username</th>
                                <th scope="col">Role</th>
                            </tr>
                        </thead>
                        <tbody>
                            {users.map((b) => (
                                <UserItem
                                    user={b}
                                    index={++indexIncrement}
                                    key={b.id}
                                    isAdmin={true}
                                    setTargetId={setDeleteTargetId}
                                />
                            ))}
                        </tbody>
                    </table>
                    <Pagination {...pagination} />
                </div>
            </div>

            <ConfirmModal
                id="modalDelete"
                action="delete"
                confirmMessage="Are you sure you want to delete this user?"
                title="Delete user"
                handleConfirm={deleteUser}
                targetId={deleteTargetId}
            />
        </>
    );
}
