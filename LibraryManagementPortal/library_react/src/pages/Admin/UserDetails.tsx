import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import RequestCardItem from "../../components/RequestCardItem";
import UserInfo from "../../components/UserInfo";
import User from "../../models/User";
import APICaller from "../../services/APICaller.service";

export default function AdminUserDetails() {
    const { id } = useParams<{ id: string }>();
    const [stateChange, setStateChange] = useState(false);
    const [user, setUser] = useState<User>({
        id: "",
        username: "",
        role: 0,
    });

    useEffect(() => {
        (async () => {
            const userDetails: User = await APICaller.getUserById(id);

            setUser(userDetails);
        })();
    }, [id, stateChange]);

    return (
        <div className="container col-12 mt-5">
            <div className="row">
                <h2 className="col-12 text-center">User details</h2>

                <div className="col-12 container mt-3">
                    <div className="row">
                        <UserInfo user={user} isAdmin={false} />
                    </div>
                </div>
                <div className="col-12 container mt-3">
                    <div className="row">
                        <RequestCardItem
                            stateChange={stateChange}
                            setStateChange={setStateChange}
                            requests={user.requests ?? []}
                            isAdmin={true}
                        />
                    </div>
                </div>
            </div>
        </div>
    );
}
