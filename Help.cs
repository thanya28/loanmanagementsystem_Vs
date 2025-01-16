using System;
using System.Collections.Generic;

namespace loanmgsystem.Model;

public partial class Help
{
    public int HelpId { get; set; }

    public string Query { get; set; } = null!;

    public string? Response { get; set; }
}
