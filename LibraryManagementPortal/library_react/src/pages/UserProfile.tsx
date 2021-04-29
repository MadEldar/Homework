import { BookRequestItem } from "../components/BookRequestItem";
import { UserInfo } from "../components/UserInfo";

export function UserProfile() {
    return (
        <>
            <div className="col-12 container">
                <div className="row">
                    <UserInfo isAdmin={false} />
                </div>
            </div>
            <div className="col-12 container">
                <div className="row">
                    <BookRequestItem />
                </div>
            </div>
        </>
    );
}
