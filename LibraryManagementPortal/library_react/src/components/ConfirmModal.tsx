import StringFormatter from "../helpers/StringFormatter";

export default function ConfirmModal({
    title,
    confirmMessage,
    action,
    id,
    handleConfirm,
}: {
    title: string;
    confirmMessage: string;
    action: string;
    id: string;
    handleConfirm: Function;
}) {
    function onConfirm() {
        handleConfirm();

        const el = document.getElementById("closeModal");
        if (el) {
            var event = document.createEvent("HTMLEvents");
            event.initEvent("click");
            el.dispatchEvent(event);
        }
    }
    return (
        <div className="modal fade" id={id}>
            <div className="modal-dialog">
                <div className="modal-content">
                    <div className="modal-header">
                        <h5 className="modal-title">
                            {StringFormatter.capitalize(title)}
                        </h5>
                        <button
                            type="button"
                            className="close"
                            data-dismiss="modal"
                            aria-label="Close"
                        >
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div className="modal-body">
                        <p>{StringFormatter.capitalize(confirmMessage)}</p>
                    </div>
                    <div className="modal-footer">
                        <button
                            id="closeModal"
                            type="button"
                            className="btn btn-secondary"
                            data-dismiss="modal"
                        >
                            Close
                        </button>
                        <button
                            type="button"
                            className="btn btn-primary"
                            onClick={() => onConfirm()}
                        >
                            {StringFormatter.capitalize(action)}
                        </button>
                    </div>
                </div>
            </div>
        </div>
    );
}
