import { render } from "solid-js/web";
import "./styles.css";
import Note from "./components/Note.tsx";

const starterNotes: Note[] = [
    { id: 1, text: "Welcome to Sticky Notes!", color: "yellow" },
    { id: 2, text: "Build something brilliant.", color: "blue" },
    { id: 3, text: "Your next idea belongs here.", color: "pink" },
];

function App() {
    return (
        <main class="min-h-screen bg-slate-50 px-6 py-12 text-slate-900">
            <section class="mx-auto max-w-5xl">
                <header class="mb-10 flex items-end justify-between">
                    <div>
                        <p class="mb-2 text-sm font-semibold uppercase tracking-widest text-indigo-600">
                            Your workspace
                        </p>
                        <h1 class="text-4xl font-bold tracking-tight">
                            Sticky Notes
                        </h1>
                    </div>
                    <button class="rounded-xl bg-indigo-600 px-4 py-2.5 font-semibold text-white shadow-sm transition hover:bg-indigo-500">
                        + New note
                    </button>
                </header>
                <div class="grid gap-5 sm:grid-cols-2 lg:grid-cols-3">
                    {starterNotes.map((note) =>
                        <Note text={note.text} color={note.color} />
                    )}
                </div>
            </section>
        </main>
    );
}

render(() => <App />, document.getElementById("root")!);
