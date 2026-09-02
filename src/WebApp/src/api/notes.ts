import type {Note} from "../types.ts";

export async function getNotes(): Promise<Note[]> {
    const response = await fetch("/api/notes");
    if (!response.ok) {
        throw new Error("Failed to fetch notes");
    }
    return await response.json();
}

export async function createNote(note: Note): Promise<Note> {
    const response = await fetch("/api/notes", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(note),
    });
    if (!response.ok) {
        throw new Error("Failed to create note");
    }
    return await response.json();
}
