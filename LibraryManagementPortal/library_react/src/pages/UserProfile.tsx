import { useEffect, useState } from "react";
import RequestCardItem from "../components/RequestCardItem";
import UserInfo from "../components/UserInfo";
import RequestInterface from "../models/RequestInterface";
import User from "../models/User";
import APICaller from "../services/APICaller.service";

export default function UserProfile() {
    const [stateChange, setStateChange] = useState(false);
    const [user, setUser] = useState<User>({
        id: "",
        username: "",
        role: 0,
    });
    const [requests, setRequests] = useState<RequestInterface[]>([]);

    useEffect(() => {
        (async () => {
            const currentUser = await APICaller.getCurrentUser().then();
            const currentUserRequests = await APICaller.getCurrentUserRequests().then();

            setUser(currentUser.data);
            setRequests(currentUserRequests.data);
        })();
    }, [stateChange]);

    return (
        <>
            <div className="col-12 container mt-3">
                <div className="row">
                    <UserInfo user={user} isAdmin={false} />
                </div>
            </div>
            <div className="col-12 container mt-3">
                <div className="row">
                    <RequestCardItem
                        setStateChange={setStateChange}
                        stateChange={stateChange}
                        requests={requests}
                        isAdmin={false}
                    />
                </div>
            </div>
        </>
    );
}
