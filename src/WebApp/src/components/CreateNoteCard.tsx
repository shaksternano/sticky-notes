import {FiX} from "solid-icons/fi";
import {createSignal} from "solid-js";
import {createNote} from "../api/notes.ts";
import type {Note} from "../types.ts";

export interface CreateNoteCardProps {
    ref?: (element: HTMLDialogElement) => void;
    onCreate?: (note: Note) => void;
}

export default function CreateNoteCard(props: CreateNoteCardProps) {
    let dialogRef!: HTMLDialogElement;
    let formRef!: HTMLFormElement;
    const [noteText, setNoteText] = createSignal("");

    async function handleSubmit(event: SubmitEvent) {
        event.preventDefault();
        const color = (Math.random() * 0xFFFFFF << 0).toString(16).padStart(6, "0");
        const note = await createNote({
            id: "",
            text: noteText(),
            color: color,
        })
        if (props.onCreate) {
            props.onCreate(note);
        }
        setNoteText("");
        dialogRef.close();
    }

    return (
        <dialog
            ref={((element) => {
                dialogRef = element;
                if (props.ref) {
                    props.ref(element);
                }
            })}
            class="left-1/2 top-1/2 -translate-x-1/2 -translate-y-1/2 w-2/3 max-w-xl h-1/2 max-h-96 rounded-2xl shadow-sm bg-white"
        >
            <div class="w-full h-full flex flex-col gap-4 overflow-x-auto p-8 relative">
                <h2 class="text-2xl font-bold tracking-tight">
                    Create a new note
                </h2>
                <form ref={formRef} method="post" onsubmit={handleSubmit} class="w-full h-full">
                    <textarea
                        placeholder="Type your note here..."
                        value={noteText()}
                        oninput={(e) => setNoteText(e.currentTarget.value)}
                        onKeyDown={(e) => {
                            if (e.key === "Enter" && !e.shiftKey) {
                                e.preventDefault()
                                formRef.requestSubmit()
                            }
                        }}
                        class="w-full h-full min-h-16 resize-none rounded-lg border border-gray-300 p-4 text-lg"
                    />

                    <button
                        type="submit"
                        class="absolute bottom-12 right-12 w-20 rounded-xl bg-gray-200 hover:bg-gray-300 transition px-4 py-2.5 font-semibold text-gray-700"
                    >
                        Create
                    </button>
                </form>

                <button class="absolute top-4 right-4" onclick={() => dialogRef.close()}>
                    <FiX />
                </button>
            </div>
        </dialog>
    );
}
