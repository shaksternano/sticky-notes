import {render} from "solid-js/web";
import "./styles.css";
import NoteCard from "./components/NoteCard.tsx";
import CreateNoteCard from "./components/CreateNoteCard.tsx";
import {createResource} from "solid-js";
import {getNotes} from "./api/notes.ts";

function App() {
    let createNoteCardRef!: HTMLDialogElement;
    const [notes, {mutate, refetch}] = createResource(getNotes)

    return (
        <main class="min-h-screen bg-slate-50 px-6 py-12 text-slate-900">
            <section class="max-w-5xl mx-auto flex flex-col gap-10">
                <header class="sticky top-0 z-10 flex items-end justify-between">
                    <div class="-m-4 p-4 rounded-2xl bg-slate-50">
                        <p class="mb-2 text-sm font-semibold uppercase tracking-widest text-indigo-600">
                            Your workspace
                        </p>
                        <h1 class="text-4xl font-bold tracking-tight">
                            Sticky Notes
                        </h1>
                    </div>
                    <button
                        onclick={() => createNoteCardRef.showModal()}
                        class="rounded-xl bg-indigo-600 px-4 py-2.5 font-semibold text-white shadow-sm transition hover:bg-indigo-500"
                    >
                        + New note
                    </button>
                </header>
                <div class="grid gap-5 sm:grid-cols-2 lg:grid-cols-3">
                    {notes()?.map((note) =>
                        <NoteCard text={note.text} color={note.color} />
                    )}
                </div>
            </section>

            <CreateNoteCard
                ref={(element) => (createNoteCardRef = element)}
                onCreate={(note) => {
                    mutate((notes) => [note, ...notes ?? []]);
                    refetch();
                }}
            />
        </main>
    );
}

render(() => <App />, document.getElementById("root")!);
